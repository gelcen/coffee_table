using Kompas6API5;
using Kompas6Constants3D;
using System;

namespace TablePlugin
{
    /// <summary>
    /// Класс для построения столика в КОМПАС 3D
    /// </summary>
    public class KompasBuilder
    {
        /// <summary>
        /// Указатель для работы с Компасом
        /// </summary>
        private KompasObject _kompas = null;

        /// <summary>
        /// Половина длины стороны столешницы. 
        /// Используется для построения эскиза столешницы с помощью ksLineSeg (отрезков)
        /// </summary>
        private double _halfX;

        /// <summary>
        /// Половина длины стороны столешницы
        /// </summary>
        private double _halfY;

        /// <summary>
        /// Ссылка на вспомогательную плоскость для ножек
        /// </summary>
        private ksEntity _legsOffsetPlane;


        /// <summary>
        /// Конструктор. Включает Компас и создает документ
        /// </summary>
        /// <param name="tableSettings">Параметры столика, из которого Компас построит его</param>
        public KompasBuilder(TableSettings tableSettings)
        {
            if (_kompas == null)
            {
                Type t = Type.GetTypeFromProgID("Kompas.Application.5");
                _kompas = (KompasObject)Activator.CreateInstance(t);
            }
            
            if (_kompas != null)
            {
                try
                {
                    _kompas.Visible = true;
                    _kompas.ActivateControllerAPI();
                }
                catch 
                {
                    Type t = Type.GetTypeFromProgID("Kompas.Application.5");
                    _kompas = (KompasObject)Activator.CreateInstance(t);
                    _kompas.Visible = true;
                    _kompas.ActivateControllerAPI();
                }
            }

            var document = (ksDocument3D)_kompas.Document3D();
            document.Create();

            BuildTabletop(tableSettings);
            BuildLegs(tableSettings);

            if (tableSettings.WithSeptums)
            {
                BuildSeptums(tableSettings);
            }

            if (tableSettings.RoundedEdgesTabletop)
            {
                RoundTabletop(tableSettings);
            }
        }

        /// <summary>
        /// Строит столешницу центром (0, 0) на плоскости XOY
        /// </summary>
        /// <param name="tableSettings">Параметры столика</param>
        private void BuildTabletop(TableSettings tableSettings)
        {
            _halfX = (double)tableSettings.TabletopLength / 2.0d;
            _halfY = (double)tableSettings.TabletopLength / 2.0d;
             
            var document = (ksDocument3D)_kompas.ActiveDocument3D();
            var part = (ksPart)document.GetPart((short)Part_Type.pTop_Part);
            var basePlane = (ksEntity)part.GetDefaultEntity(
                (short)Obj3dType.o3d_planeXOY);
            if (part != null)
            {
                var sketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
                if (sketch != null)
                {
                    sketch.name = "Эскиз столешницы";
                    var sketchDef = (ksSketchDefinition)sketch.GetDefinition();
                    if (sketchDef != null)
                    {
                        sketchDef.SetPlane(basePlane);
                        sketch.Create();

                        var draw = (ksDocument2D)sketchDef.BeginEdit();
                        draw.ksLineSeg(-_halfX, -_halfY,
                                        _halfX, -_halfY, 1);
                        draw.ksLineSeg(_halfX, -_halfY,
                                       _halfX, _halfY, 1);
                        draw.ksLineSeg(_halfX, _halfY,
                                       -_halfX, _halfY, 1);
                        draw.ksLineSeg(-_halfX, _halfY,
                            -_halfX, -_halfY, 1);
                        sketchDef.EndEdit();

                        var extr = (ksEntity)part.NewEntity(
                            (short)Obj3dType.o3d_bossExtrusion);
                        if (extr != null)
                        {
                            extr.name = "Выдавливание столешницы";
                            var extrDef = (ksBossExtrusionDefinition)extr.GetDefinition();
                            if (extrDef != null)
                            {
                                extrDef.directionType = (short)Direction_Type.dtNormal;
                                extrDef.SetSideParam(true, (short)End_Type.etBlind, 
                                                     tableSettings.TabletopThickness);
                                extrDef.SetSketch(sketch);
                                extr.Create();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Функция построения ножек
        /// </summary>
        /// <param name="tableSettings">Параметры столика</param>
        private void BuildLegs(TableSettings tableSettings)
        {
            var document = (ksDocument3D)_kompas.ActiveDocument3D();
            var part = (ksPart)document.GetPart((short)Part_Type.pTop_Part);
            if (part != null)
            {
                var legsOffsetPlane = (ksEntity)part.NewEntity((short)Obj3dType.o3d_planeOffset);
                var legsOffsetPlaneDef = (ksPlaneOffsetDefinition)legsOffsetPlane.GetDefinition();

                var basePlane = (ksEntity)part.GetDefaultEntity(
                    (short)Obj3dType.o3d_planeXOY);

                legsOffsetPlaneDef.SetPlane(basePlane);
                legsOffsetPlaneDef.offset = tableSettings.TabletopThickness;
                legsOffsetPlane.Create();

                _legsOffsetPlane = legsOffsetPlane;

                var legsSketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
                if (legsSketch != null)
                {
                    legsSketch.name = "Эскиз ножек";
                    var legsSketchDefinition = (ksSketchDefinition)legsSketch.GetDefinition();
                    if (legsSketchDefinition != null)
                    {
                        legsSketchDefinition.SetPlane(legsOffsetPlane);
                        legsSketch.Create();

                        var draw = (ksDocument2D)legsSketchDefinition.BeginEdit();
                        DrawLeg(draw, -_halfX, _halfY, tableSettings.LegLength);
                        DrawLeg(draw, -_halfX, -_halfY + tableSettings.LegLength,
                                tableSettings.LegLength);
                        DrawLeg(draw, _halfX - tableSettings.LegLength, _halfY,
                                tableSettings.LegLength);
                        DrawLeg(draw, _halfX - tableSettings.LegLength, -_halfY + tableSettings.LegLength,
                                tableSettings.LegLength);
                        legsSketchDefinition.EndEdit();

                        var extr = (ksEntity)part.NewEntity(
                                        (short)Obj3dType.o3d_bossExtrusion);
                        if (extr != null)
                        {
                            extr.name = "Выдавливание ножек";
                            var extrDef = (ksBossExtrusionDefinition)extr.GetDefinition();
                            if (extrDef != null)
                            {
                                extrDef.directionType = (short)Direction_Type.dtNormal;
                                extrDef.SetSideParam(true, (short)End_Type.etBlind,
                                                     tableSettings.LegHeight);
                                extrDef.SetSketch(legsSketch);
                                extr.Create();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Построение разделителей
        /// </summary>
        /// <param name="tableSettings">Параметры столика</param>
        private void BuildSeptums(TableSettings tableSettings)
        {
            var document = (ksDocument3D)_kompas.ActiveDocument3D();
            var part = (ksPart)document.GetPart((short)Part_Type.pTop_Part);
            if (part != null)
            {
                var septumOffsetPlane = (ksEntity)part.NewEntity(
                    (short)Obj3dType.o3d_planeOffset);
                var septOffsetPlaneDef = (ksPlaneOffsetDefinition)
                    septumOffsetPlane.GetDefinition();
                septOffsetPlaneDef.SetPlane(_legsOffsetPlane);
                septOffsetPlaneDef.offset = tableSettings.SeptumOffset;
                septumOffsetPlane.Create();

                var septumSketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
                if (septumSketch != null)
                {
                    septumSketch.name = "Эскиз разделителей";
                    var septumSketchDef = (ksSketchDefinition)septumSketch.GetDefinition();
                    septumSketchDef.SetPlane(septumOffsetPlane);
                    septumSketch.Create();

                    double a = 20;
                    double b = (_halfX - tableSettings.LegLength) - (-_halfX + tableSettings.LegLength);

                    var sketchEdit = septumSketchDef.BeginEdit();
                    DrawSeptum(sketchEdit, -_halfX + tableSettings.LegLength, _halfY-10,
                        a, b, 0);
                    DrawSeptum(sketchEdit, _halfX - 10, 
                        _halfY - tableSettings.LegLength,
                        b, a, 1);
                    DrawSeptum(sketchEdit, -_halfX + tableSettings.LegLength,
                        -_halfY + 10, 
                        a, b, 2);
                    DrawSeptum(sketchEdit, -_halfX+10, _halfY - tableSettings.LegLength, b, a, 0);
                    septumSketchDef.EndEdit();

                    var extr = (ksEntity)part.NewEntity(
                                        (short)Obj3dType.o3d_bossExtrusion);
                    if (extr != null)
                    {
                        extr.name = "Выдавливание разделителей";
                        var extrDef = (ksBossExtrusionDefinition)extr.GetDefinition();
                        if (extrDef != null)
                        {
                            extrDef.directionType = (short)Direction_Type.dtNormal;
                            extrDef.SetSideParam(true, (short)End_Type.etBlind,
                                                 tableSettings.SeptumLength);
                            extrDef.SetSketch(septumSketch);
                            extr.Create();
                        }
                    }



                }

            }
        }

        /// <summary>
        /// Функция для рисования эскиза ножек столика
        /// </summary>
        /// <param name="sketchEdit">Объект рисования эскиза</param>
        /// <param name="x">Координата х верхней левой точки квадратной ножки</param>
        /// <param name="y">Координата у верхней левой точки квадратной ножки</param>
        /// <param name="sideLength">Длина стороны квадратной ножки</param>
        private void DrawLeg(ksDocument2D sketchEdit, double x, double y, 
                                   double sideLength)
        {                   
            sketchEdit.ksLineSeg(x, y, x+sideLength, y, 1);
            sketchEdit.ksLineSeg(x+sideLength, y, 
                                 x+sideLength, y-sideLength, 1);
            sketchEdit.ksLineSeg(x + sideLength, y - sideLength, 
                                 x, y - sideLength, 1);
            sketchEdit.ksLineSeg(x, y - sideLength, x, y, 1);
        }

        /// <summary>
        /// Функция для рисовки разделителей
        /// </summary>
        /// <param name="sketchEdit">Объект рисования эскиза</param>
        /// <param name="x">Координата х </param>
        /// <param name="y">Координата у </param>
        /// <param name="a">Сторона прямоугольника 1</param>
        /// <param name="b">Сторона прямоугольника 2</param>
        private void DrawSeptum(ksDocument2D sketchEdit, double x, double y, double a, double b, int type)
        {
            if (type == 0)
            {
                sketchEdit.ksLineSeg(x, y, x + b, y, 1);
                sketchEdit.ksLineSeg(x + b, y, x + b, y - a, 1);
                sketchEdit.ksLineSeg(x + b, y - a, x, y - a, 1);
                sketchEdit.ksLineSeg(x, y - a, x, y, 1);
            }
            if (type == 1)
            {
                sketchEdit.ksLineSeg(x, y, x, y - a, 1);
                sketchEdit.ksLineSeg(x, y - a, x - b, y - a, 1);
                sketchEdit.ksLineSeg(x - b, y - a, x - b, y, 1);
                sketchEdit.ksLineSeg(x - b, y, x, y, 1);
            }
            if (type == 2)
            {
                sketchEdit.ksLineSeg(x, y, x, y + a, 1);
                sketchEdit.ksLineSeg(x, y + a, x + b, y + a, 1);
                sketchEdit.ksLineSeg(x + b, y + a, x + b, y, 1);
                sketchEdit.ksLineSeg(x + b, y, x, y, 1);
            }
        }
        /// <summary>
        /// Скругление краев столешницы
        /// </summary>
        /// <param name="tableSettings">Параметры столешницы</param>
        private void RoundTabletop(TableSettings tableSettings)
        {
            var document = (ksDocument3D)_kompas.ActiveDocument3D();
            var part = (ksPart)document.GetPart((short)Part_Type.pTop_Part);

            var fillet = (ksEntity)part.NewEntity((short)Obj3dType.o3d_fillet);
            if (fillet != null)
            {
                fillet.name = "Скругление краёв столешницы";
                var filletDef = (ksFilletDefinition)fillet.GetDefinition();
                if (filletDef != null)
                {
                    filletDef.radius = 5;
                    filletDef.tangent = false;

                    var edgeArrayY = (ksEntityCollection)part.EntityCollection(
                        (short)Obj3dType.o3d_edge);
                    var edgeArrayYminus = (ksEntityCollection)part.EntityCollection(
                        (short)Obj3dType.o3d_edge);
                    var edgeArrayX = (ksEntityCollection)part.EntityCollection(
                        (short)Obj3dType.o3d_edge);
                    var edgeArrayXminus = (ksEntityCollection)part.EntityCollection(
                        (short)Obj3dType.o3d_edge);

                    edgeArrayY.SelectByPoint(0, _halfY, 0);
                    edgeArrayYminus.SelectByPoint(0, -_halfY, 0);
                    edgeArrayX.SelectByPoint(_halfX, 0, 0);
                    edgeArrayXminus.SelectByPoint(-_halfX, 0, 0);


                    var filletArray = (ksEntityCollection)filletDef.array();
                    filletArray.Clear();

                    filletArray.Add(edgeArrayY.First());
                    filletArray.Add(edgeArrayYminus.First());
                    filletArray.Add(edgeArrayX.First());
                    filletArray.Add(edgeArrayXminus.First());
                    
                    fillet.Create();
                }
            }
        }
    }
}
