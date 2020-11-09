import React from "react";
import { BrowserRouter } from 'react-router-dom';

function BlogCard({ blog }) {
  return (
    <div className="card">
      <div className="card-body">
        <h5 className="card-title">{blog.name}</h5>
        <h6 className="card-subtitle">Author: {blog.author}</h6>
        <h6 className="card-subtitle">Category: {blog.category}</h6>
        <BrowserRouter>
    
        </BrowserRouter>
      </div>
    </div>
  );
}

export default BlogCard;
