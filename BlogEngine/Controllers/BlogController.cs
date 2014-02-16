using System.Collections.Generic;
using System.Web.Mvc;
using BL;
using BlogEntities.Models;
using DAL.Base;

namespace BlogEngine.Controllers
{
    public class BlogController : Controller
    {
        //Not needed due to BlogService & UnitOfWork
        //private BlogEntitiesContext db = new BlogEntitiesContext();
       
        //
        // GET: /Blog/

        public ActionResult Index()
        {
            //Includes posts
            List<Blog> blogList = BlogService.GetAllBlogs();

            foreach (Blog blog in blogList)
            {
                //Attempting to prevent major UI failures
                //Limit Title of Blog to be displayed with 45chars adding the dots
                if (blog.BlogDescription.Length > 45)
                    blog.BlogDescription = blog.BlogDescription.Substring(0, 45) + ".....";
            }

            return blogList.Count <= 0 ? View() : View(blogList);
        }

        //
        // GET: /Blog/Details/5

        public ActionResult Details(int id = 0)
        {
            
            var blog = BlogService.GetById(id);
            
            return blog == null ? (ActionResult)HttpNotFound() : View(blog); 
        }

        //
        // GET: /Blog/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        //GET: Blog/CreatePost?blogId={0}
        public ActionResult CreatePost(int blogId)
        {
            //TODO: Add viewmodel code here due to displaying data from Posts & Blog

            var blog = BlogService.GetById(blogId);

            if (blog == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.BlogDesc = blog.BlogDescription;

            return View();
        }

        //
        // POST: /Blog/Post/Create{post, blogId}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(Post post, int blogId)
        {
            if (ModelState.IsValid)
            {
                //find the Blog attached by Id
                var currentBlog = BlogService.GetById(blogId);
                
                BlogService.AttachPostToBlog(currentBlog.BlogId);

                post.BlogId = currentBlog.BlogId;

                var currentPost = post;

                BlogService.Add(currentPost);

                //This calls Context.SaveChanges()
                UnitOfWork.Commit();

                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        //
        // POST: /Blog/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                var createBlog = blog;

                BlogService.Add(createBlog);

                //This calls Context.SaveChanges()
                UnitOfWork.Commit();
                
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View();
        }

        //
        // GET: /Blog/Edit/5

        public ActionResult Edit(int id = 0)
        {

            //Blog blog = db.Blogs.Find(id);
            var blog = BlogService.GetById(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        //
        // POST: /Blog/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(blog).State = EntityState.Modified;
                //This sets EntityState to modified
                var blogEdited = BlogService.Update(blog);
  
                UnitOfWork.Commit();

                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        //
        // GET: /Blog/Delete/5

        public ActionResult Delete(int id = 0)
        {

            var blog = BlogService.GetById(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        //
        // POST: /Blog/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Find Id, make a blog
            var blog = BlogService.GetById(id);
            
            //Remove blog
            BlogService.Remove(blog);
            
            //Save Changes
            UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            UnitOfWork.Current.Dispose();
            //db.Dispose();
            base.Dispose(disposing);
        }
    }
}