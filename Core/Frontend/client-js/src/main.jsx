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

  render() {
    return (
      <div className="container">
        {this.state.blogs.forEach((element) => {
          console.log(element);
          <BlogCard blog={element} />;
        })}
      </div>
    );
  }
}

export default Main;
