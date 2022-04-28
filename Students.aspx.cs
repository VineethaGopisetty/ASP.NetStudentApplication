using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContosoUniversityModelBinding.Models;
using System.Data.Entity;

namespace EmpData
{
    public partial class Students : System.Web.UI.Page
    {
        /*protected void Page_Load(object sender, EventArgs e)
        {
           

        }*/
        public IQueryable<Student> studentsGrid_GetData()
        {
            SchoolContext db = new SchoolContext();
            var query = db.Students.Include(s => s.Enrollments.Select(e => e.Course));
            return query;
        }

        protected void studentsGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void studentsGrid_UpdateItem(int id)
        {
            ContosoUniversityModelBinding.Models.Student item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();

            }
        }
    }
}