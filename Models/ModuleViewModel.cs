using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace CollegeSystem.Models
{
    public class ModuleViewModel
    {

        public Module Module { get; set; }

        public IEnumerable<SelectListItem> AllLecturers { get; set; }
        private List<int> _selectedLecturers;

        public IEnumerable<SelectListItem> AllCourses { get; set; }
        private List<int> _selectedCourses;

        public List<int> SelectedLecturers
        {
            get
            {
                if (_selectedLecturers == null)
                {
                    _selectedLecturers = new List<int>();
                    if (Module.Lecturers != null)
                    {
                        _selectedLecturers = Module.Lecturers.Select(l => l.Id).ToList();
                    }
                }
                return _selectedLecturers;
            }
            set
            {
                _selectedLecturers = value;
            }
        }

        public List<int> SelectedCourses
        {
            get
            {
                if (_selectedCourses == null)
                {
                    _selectedCourses = new List<int>();
                    if (Module.Courses != null)
                    {
                        _selectedCourses = Module.Courses.Select(c => c.Id).ToList();
                    }
                }
                return _selectedCourses;
            }
            set
            {
                _selectedCourses = value;
            }
        }


    }
}