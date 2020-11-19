import React, { Component } from "react";
import $ from "jquery";

import BlogCard from "./components/blogCard";

class Main extends Component {
  state = {
    blogs: [],
    url: "https://blog-engine-api.herokuapp.com/api/blogs",
  };

  componentDidMount() {
    $.get(this.state.url, (data) => {
      this.setState({ blogs: data });
    });
  }

  renderBlogs = (blogs) => {
    console.log("It's fucked");
    return blogs.forEach((element) => {
      console.log("Is it working?");
      return <BlogCard blog={element} />;
    });
  };

  render() {
    return (
      <div className="container">{this.renderBlogs(this.state.blogs)}</div>
    );
  }
}

export default Main;
