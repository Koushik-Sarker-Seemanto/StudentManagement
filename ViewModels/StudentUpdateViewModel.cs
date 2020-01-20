using System;
using System.ComponentModel.DataAnnotations;
using StudentManagement.Models;

namespace StudentManagement.ViewModels
{
    public class StudentUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dept Dept { get; set; }

        public string Email { get; set; }
        public int Batch { get; set; }
        // public StudentUpdateViewModel()
        // {
        //     
        // }
        //
        // public StudentUpdateViewModel(int id, string name, Dept dept, string email, int batch)
        // {
        //     this.Id = id;
        //     this.Name = name;
        //     this.Dept = dept;
        //     this.Email = email;
        //     this.Batch = batch;
        // }
    }
}