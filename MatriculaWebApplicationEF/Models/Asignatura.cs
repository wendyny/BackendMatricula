﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.Models
{
    public class Asignatura
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Docente> DocentesPorAsignatura { get; set; }

    }
}
