using Lab1.Models;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Views.ViewComponents
{
    public class LeftMenuViewComponent : ViewComponent
    {
        private List<MenuItem> _listItems = new List<MenuItem>();
        public LeftMenuViewComponent()
        {
            _listItems = new List<MenuItem>()
            {
                new MenuItem() { Id = 1, Name = "Branches", Link = "Branches/List" },
                new MenuItem() { Id = 2, Name = "Students", Link = "Students/List" },
                new MenuItem() { Id = 3, Name = "Subjects", Link = "Subjects/List" },
                new MenuItem() { Id = 4, Name = "Courses", Link = "Courses/List" }
            };
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderLeftMenu", _listItems);
        }
    }
}
