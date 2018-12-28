using finalproyect.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace finalproyect.Pages {
    
    
    public class CreateMusicModel : PageModel {
        public readonly AppDbContext _db;
        public CreateMusicModel(AppDbContext _db){
            this._db = _db;
        }
        public string Message { get; set;}
       
        public IActionResult OnGet() {
            Message = "Crear nueva cancion";
            return Page();
        }


        public IActionResult OnPost(string inputName, string inputAlbum, string inputGenre, string inputArtist, string inputYear){
            Music music = new Music(){
                Name = inputName,
                Album = inputAlbum,
                Genre = inputGenre,
                Artist = inputArtist,
                Year = inputYear
            };
            _db.Musics.Add(music);
            _db.SaveChanges();
         return Page();   
        }
    }
}