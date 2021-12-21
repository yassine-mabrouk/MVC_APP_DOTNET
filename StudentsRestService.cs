using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using webProject.Model;

namespace webProject
{
    [Route("/api/students")]
    public class StudentsRestService:Controller{
        private MyDbContext dbService;
        public StudentsRestService(MyDbContext dbContext){
            dbService=dbContext;
        }
        [HttpGet]
        public IEnumerable<Student> list(){
            return dbService.students;
        }
        [HttpGet("{Id}")]
        public Student getOne(long Id){
            return dbService.students.FirstOrDefault(s=>s.Id==Id);
        }
        [HttpPost]
        public Student save([FromBody]Student student){
            dbService.students.Add(student);
            dbService.SaveChanges();
            return student;
        }
        [HttpDelete("{Id}")]
        public void delete(long Id){
            Student student=dbService.students.FirstOrDefault(s=>s.Id==Id);
            dbService.students.Remove(student);
            dbService.SaveChanges();
        }
        [HttpPut("{Id}")]
        public Student update(long Id,[FromBody]Student student){
            student.Id=Id;
            dbService.students.Update(student);
            dbService.SaveChanges();
            return student;
        }
    }
}