
using AutoMapper;
using BlogApi.src.DB;
using BlogApi.src.Models;
using BlogApi.src.Repository.Generic;
using Microsoft.EntityFrameworkCore;


namespace BlogApi.src.Repository
{
    public class PostRepository(DBContext context) : Repository<Post>(context), IPostRepository
    {

    }
}