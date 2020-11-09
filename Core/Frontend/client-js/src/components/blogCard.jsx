import React from "react"
import { BrowserRouter, Switch, Link } from 'react-router-dom'

function BlogCard({ blog }) {
  return (
    <div className="card">
      <div className="card-body">
        <h5 className="card-title">{blog.name}</h5>
        <h6 className="card-subtitle">Author: {blog.author}</h6>
        <h6 className="card-subtitle">Category: {blog.category}</h6>
        <BrowserRouter>
            <Switch>
                <Link to={"/blog/" + blog.blogUrl}>See Posts</Link>
            </Switch>
        </BrowserRouter>
      </div>
    </div>
  );
}

export default BlogCard
