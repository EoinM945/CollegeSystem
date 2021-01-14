using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeSystem.Models
{
    public class StudentViewModel
    {
        public Student Student { get; set; }

        
        public IEnumerable<SelectListItem> AllModules { get; set; }
        private List<int> _selectedModules;

        


        public List<int> SelectedModules
        {
            get
            {
                if (_selectedModules == null)
                {
                    _selectedModules = new List<int>();
                    if (Student.Modules != null)
                    {
                        _selectedModules = Student.Modules.Select(m => m.Id).ToList();
                    }
                }
                return _selectedModules;
            }
            set
            {
                _selectedModules = value;
            }
        }



    }
}