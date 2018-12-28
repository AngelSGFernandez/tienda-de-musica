using finalproyect.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace finalproyect.Pages {
    
    
    public class EditMusicModel : PageModel {
        public readonly AppDbContext _db;
        public EditMusicModel(AppDbContext _db){
            this._db = _db;
        }
        public string Message { get; set;}
        public Music Music { get; set;}
       
        public IActionResult OnGet(int id) {
            Music = _db.Musics.Find(id);//SELECT*FROM Musics WHERE id = id
            Message = $"Editar {Music.Name}";
            return Page();
        }


        public IActionResult OnPost(int hiddenId, string inputName, string inputAlbum, string inputGenre, string inputArtist, string inputYear){
            Music = _db.Musics.Find(hiddenId);
            Music.Name = inputName;
            Music.Album = inputAlbum;
            Music.Genre = inputGenre;
            Music.Year = inputYear;
            Music.Artist = inputArtist;

            _db.Musics.Update(Music);
            _db.SaveChanges();

            return Page();   
        }
    }
}