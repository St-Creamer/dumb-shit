﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BrightPathDev.Controllers
{
    public partial  class ArticleController : Controller
    {
        // GET: Article/Delete/5
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Article/Delete/5
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            var userId = _userManager.GetUserId(HttpContext.User);
            var deleteList = await _context.DeleteLists.FindAsync(id);

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Image", userId, article.ArticleId.ToString());
            if (Directory.Exists(uploads))
            {
                Directory.Delete(uploads, true);
            }
            if (article == null )
            {
                _context.DeleteLists.Remove(deleteList);
                if (deleteList == null)
                {
                    return NotFound();
                }
                
            }
            var flag = await _context.Flags.FindAsync(article.ArticleId);
            _context.Remove(flag);
            
            foreach (var item in _context.Comments.ToList())
            {
                if(item.ArticleId == article.ArticleId)
                {
                    _context.Remove(item);
                }
            }
            _context.Articles.Remove(article);
            
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
