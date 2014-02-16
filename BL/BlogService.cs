using System;
using System.Collections.Generic;
using System.Linq;
using BlogEntities.Models;
using DAL;
using StructureMap;

namespace BL
{
    public static class BlogService
    {
        //Get an instance of Blogs
        private static IRepository<Blog> BlogRepository
        {
            get { return ObjectFactory.GetInstance<IRepository<Blog>>(); }
        }

        //Get an instance of Posts
        private static IRepository<Post> PostRepository
        {
            get { return ObjectFactory.GetInstance<IRepository<Post>>(); }
        }
        
        /// <summary>
        /// Returns ALL Blogs by a list
        /// </summary>
        /// <returns></returns>
        public static List<Blog> GetAllBlogs()
        {
            var blogList = BlogRepository.GetAll().ToList();
            return blogList;
        }

        /// <summary>
        /// Returns ALL Posts by a list
        /// </summary>
        /// <returns></returns>
        public static List<Post> GetAllPosts()
        {
            var postList = PostRepository.GetAll().ToList();
            return postList;
        }

        /// <summary>
        /// Returns a given Blog by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Blog GetById(int id)
        {
            var blogFound = BlogRepository.GetById(id);
            return blogFound;
        }
        
        /// <summary>
        /// Returns a boolean result from adding the blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public static bool Add(Blog blog)
        {
            if (!String.IsNullOrEmpty(blog.Author) && !String.IsNullOrEmpty(blog.BlogDescription))
            {
                BlogRepository.Add(blog);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns a boolean result from adding the post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public static bool Add(Post post)
        {
            if (!String.IsNullOrEmpty(post.CurrentPost) && !String.IsNullOrEmpty(post.NickName))
            {
                PostRepository.Add(post);
            }
            return false;
        }

        /// <summary>
        /// Finds blog by id, and returns a seeded post 
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        public static Post AttachPostToBlog(int blogId)
        {
            var currentBlog = BlogRepository.GetById(blogId);
            
            var post = new Post()
                           {
                               Blog = currentBlog                   
                           };
            return post;
        }

        /// <summary>
        /// Attach a given post by parameter
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public static Post Attach(Post post)
        {
            var attachedPost = post;
            PostRepository.Attach(attachedPost);
            return attachedPost;
        }

        /// <summary>
        /// Attach a given blog by parameter
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public static Blog Attach(Blog blog)
        {
            var attachedBlog = blog;
            BlogRepository.Attach(attachedBlog);
            return attachedBlog;
        }

        /// <summary>
        /// Update a given blog by parameter
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public static Blog Update(Blog blog)
        {
            var blogUpdated = blog;
            BlogRepository.Update(blogUpdated);
            return blogUpdated;
        }

        /// <summary>
        /// Remove a given blog by parameter
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public static bool Remove(Blog blog)
        {
            BlogRepository.Delete(blog);
            return true;
        }

    }
}
