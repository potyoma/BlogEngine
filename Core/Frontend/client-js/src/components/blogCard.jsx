import React, { Component } from "react";

class BlogCard extends Component {
  render() {
    console.log("It's rendering");
    return (
      <div className="card">
        <h1>Why the fuck it is not working?!</h1>
        <div className="card-body">
          <h5 className="card-title">{this.props.name}</h5>
          <h6 className="card-subtitle">Author: {this.props.Author}</h6>
          <h6 className="card-subtitle">Category: {this.props.Category}</h6>
        </div>
      </div>
    );
  }
}

export default BlogCard;
