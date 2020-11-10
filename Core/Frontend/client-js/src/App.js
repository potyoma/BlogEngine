import React from "react";

import Main from "./main";

function App() {
  let props = {
    blogs: [],
  };

  props.blogs = getRequest()

  return (
    <div>
      <h1>Welcome!</h1>
      <Main blogs={props.blogs} />
    </div>
  );
}

function getRequest() {
  const url = "https://blog-engine-api.herokuapp.com/api/blogs"
  let result
  try {
    fetch(url)
      .then(res => res.json())
      .then(data => result = data)
    return result
  } catch (e) {
    throw new Error("Error: ", e.message)
  }
}

export default App;
 