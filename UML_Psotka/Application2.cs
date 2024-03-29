﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static UML_Psotka.Relation;

namespace UML_Psotka
{
    public class Application2
    {
        public List<Class> Classes { get; set; } = new List<Class>();
        public List<Relation> Relations { get; set; } = new List<Relation>();
        private JsonSerializerSettings js_set = new() { TypeNameHandling = TypeNameHandling.Objects, PreserveReferencesHandling = PreserveReferencesHandling.Objects };

        public Class EditClass { get; set; }

        public bool MakingRelation = false;

        public int CursorX { get; set; }
        public int CursorY { get; set; }
        public int RMX { get; set; }

        public int RMY { get; set; }


        public void Draw(Graphics g)
        {
            foreach (Relation item in Relations)
            {
                item.Draw(g, RMX, RMY);
            }

            foreach (Class item in Classes)
            {
                item.Draw(g);
            }

            if (EditClass != null)
                EditClass.Draw(g);
        }
        public void CreateClass(Frm_Class frm)
        {
            frm.ClassList = Classes;
            if (frm.ShowDialog() == DialogResult.OK)
                Classes.Add(frm.Class);
        }
        public void DoubleClick(int xM, int yM)
        {
            if (MakingRelation)
                return;
            if (EditClass != null)
                if (EditClass.X < xM && xM < EditClass.X + EditClass.Width && EditClass.Y < yM && yM < EditClass.Y + EditClass.Height)
                {
                    Frm_ClassSettings frm = new Frm_ClassSettings(EditClass, this.Classes);
                    frm.ShowDialog();
                    EditClass.RecalcDim();
                }
        }
        public void MouseUp(int xM, int yM)
        {
            if (MakingRelation)
                return;
            if (EditClass != null)
            {
                if (EditClass.X < xM && xM < EditClass.X + 20 && EditClass.Y + EditClass.Height - 20 < yM && yM < EditClass.Y + EditClass.Height)
                {
                    Frm_ClassSettings frm = new Frm_ClassSettings(EditClass, this.Classes);
                    frm.ShowDialog();
                    EditClass.RecalcDim();

                }
                else if (EditClass.X + EditClass.Width / 2 - 10 < xM && xM < EditClass.X + EditClass.Width / 2 + 10 && EditClass.Y + EditClass.Height - 20 < yM && yM < EditClass.Y + EditClass.Height)
                {
                    this.Relations.Add(new Relation(EditClass));
                    this.MakingRelation = true;
                }
                else if (EditClass.X + EditClass.Width - 20 < xM && xM < EditClass.X + EditClass.Width && EditClass.Y + EditClass.Height - 20 < yM && yM < EditClass.Y + EditClass.Height)
                {
                    Frm_DeleteClass frm = new Frm_DeleteClass(EditClass.Name);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        List<Relation> copy = new List<Relation>(this.Relations);
                        foreach (Relation item in Relations)
                        {
                            if (item.FirstClass == EditClass)
                            {
                                copy.Remove(item);
                                continue;
                            }
                            if (item.SecondClass == EditClass)
                                copy.Remove(item);
                        }
                        this.Relations = copy;

                        Classes.Remove(EditClass);
                        this.EditClass = null;
                        return;
                    }
                }
            }


        }
        public void MouseDown(int xM, int yM)
        {
            Relation rel = this.Relations.LastOrDefault();
            if (rel != null)
            {
                if (rel.SecondClass == null)
                {
                    foreach (Class item in Classes.AsEnumerable().Reverse())
                    {
                        if (item.X < xM && xM < item.X + item.Width && item.Y < yM && yM < item.Y + item.Height && rel.FirstClass != item)
                        {
                            rel.SecondClass = item;
                            this.MakingRelation = false;
                            Frm_Relation frm = new Frm_Relation(rel);
                            if (frm.ShowDialog() == DialogResult.Cancel)
                            {
                                this.Relations.Remove(rel);
                            }

                        }
                    }
                }
            }
            if (MakingRelation)
                return;

            this.CursorX = xM;
            this.CursorY = yM;
            List<Relation> _copy = new List<Relation>(this.Relations);
            foreach (Relation item in Relations)
            {
                switch (item.DeleteButtonDir)
                {
                    case direction.UP:
                        if(item.SecondClass.X + item.SecondClass.Width /2 - 10 < xM && item.SecondClass.X + item.SecondClass.Width / 2 + 10 > xM && item.SecondClass.Y - 20  < yM && item.SecondClass.Y > yM)
                        {
                            _copy.Remove(item);
                        }
                        break;
                    case direction.DOWN:
                        if (item.SecondClass.X + item.SecondClass.Width / 2 - 10 < xM && item.SecondClass.X + item.SecondClass.Width / 2 + 10 > xM && item.SecondClass.Y + item.SecondClass.Height < yM && item.SecondClass.Y + item.SecondClass.Height + 20 > yM)
                        {
                            _copy.Remove(item);
                        }
                        break;
                    case direction.RIGHT:
                        if (item.SecondClass.X + item.SecondClass.Width  < xM && item.SecondClass.X + item.SecondClass.Width + 20 > xM && item.SecondClass.Y + item.SecondClass.Height / 2 - 10 < yM && item.SecondClass.Y + item.SecondClass.Height / 2 + 10 > yM)
                        {
                            _copy.Remove(item);
                        }
                        break;
                    case direction.LEFT:
                        if (item.SecondClass.X - 20 < xM && item.SecondClass.X > xM && item.SecondClass.Y + item.SecondClass.Height / 2 - 10 < yM && item.SecondClass.Y + item.SecondClass.Height / 2 + 10 > yM)
                        {
                            _copy.Remove(item);
                        }
                        break;
                }
            }
            this.Relations = _copy;

            bool changed = false;
            foreach (Class item in Classes.AsEnumerable().Reverse())
            {
                if (item.X < xM && xM < item.X + item.Width && item.Y < yM && yM < item.Y + item.Height)
                {
                    changed = true;

                    if (item == EditClass)
                    {
                        Classes.Remove(EditClass);
                        Classes.Add(EditClass);
                        break;
                    }
                    if (EditClass != null)
                    {
                        EditClass.Editable = false;
                        Classes.Remove(EditClass);
                        Classes.Add(EditClass);
                    }
                    EditClass = item;
                    EditClass.Editable = true;
                    break;
                }
            }
            if (EditClass != null && !changed)
            {
                EditClass.Editable = false;
                Classes.Remove(EditClass);
                Classes.Add(EditClass);
                EditClass = null;
            }

        }
        public void ChangePosition(int xM, int yM)
        {
            this.RMX = xM;
            this.RMY = yM;
        }
        public void MouseMove(int xM, int yM, int pcW, int pcH)
        {
            if (MakingRelation)
                return;
            if (EditClass == null)
                return;

            EditClass.X += xM - this.CursorX;
            EditClass.Y += yM - this.CursorY;

            this.CursorX = xM;
            this.CursorY = yM;

            if (EditClass.X < 0)
                EditClass.X = 0;
            if (EditClass.Y < 0)
                EditClass.Y = 1;
            if (EditClass.X + EditClass.Width > pcW)
                EditClass.X = pcW - 1 - EditClass.Width;
            if (EditClass.Y + EditClass.Height > pcH)
                EditClass.Y = pcH - 1 - EditClass.Height;


        }
        public void GenerateCode(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists)
            {
                dir.Create();
            }

            foreach (Class item in Classes)
            {
                using (StreamWriter sw = new StreamWriter(path + @"\" + item.Name + ".cs"))
                {
                    List<Relation> listR = Relations.FindAll(x => x.SecondClass == item && x.RelationType == Relation.relationType.Inheritance);


                    sw.WriteLine("using System;");
                    sw.WriteLine("using System.Collections.Generic;");
                    sw.WriteLine("using System.Linq;");
                    sw.WriteLine("using System.Text;");
                    sw.WriteLine("using System.Threading.Tasks;");
                    sw.WriteLine("");
                    sw.WriteLine("namespace name");
                    sw.WriteLine("{");

                    string creteClass = "    public ";

                    if (item.ClassType == Class.classType.BASIC)
                    {
                        creteClass += "class ";
                    }

                    else if (item.ClassType == Class.classType.ABSTRACT)
                    {
                        creteClass += "abstract class ";
                    }

                    else if (item.ClassType == Class.classType.INTERFACE)
                    {
                        creteClass += "interface ";
                    }

                    creteClass += item.Name + " :";

                    foreach (Relation item2 in listR)
                    {
                        creteClass += $" {item2.FirstClass.Name},";
                    }
                    creteClass = creteClass.Substring(0, creteClass.Length - 1);


                    sw.WriteLine(creteClass);
                    sw.WriteLine("    {");
                    foreach (Property prop in item.Properties)
                    {
                        sw.WriteLine($"        {prop.AccessM.ToString().ToLower()} {prop.DataType.ToString().ToLower()} {prop.Name.ToString().ToLower()}" + " { get; set; }");
                    }
                    foreach (Method met in item.Methods)
                    {
                        string paramString = " ";
                        foreach (KeyValuePair<string, string> prm in met.Parameters)
                        {
                            paramString += prm.Value.ToString().ToLower() + " " + prm.Key + ",";
                        }
                        paramString = paramString.Substring(0, paramString.Length - 1);
                        sw.WriteLine($"        {met.AccessM.ToString().ToLower()} {met.Output.ToString().ToLower()} {met.Name.ToString().ToLower()}({paramString}) ");
                        sw.WriteLine("        {");
                        sw.WriteLine("            throw new NotImplementedException();");
                        sw.WriteLine("        }");
                    }
                    sw.WriteLine("    }");
                    sw.WriteLine("}");

                }
            }
        }
        public void GenerateJson(string path)
        {
            Json json_to_exp = new Json();
            json_to_exp.Classes = this.Classes;
            json_to_exp.Relations = this.Relations;
            string json = JsonConvert.SerializeObject(json_to_exp, js_set);

            File.WriteAllText(path + ".json", json);
        }
        public void ImportCode(string path)
        {
            Json json = JsonConvert.DeserializeObject<Json>(File.ReadAllText(path), js_set);
            this.Relations = json.Relations;
            this.Classes = json.Classes;
        }
    }
}
