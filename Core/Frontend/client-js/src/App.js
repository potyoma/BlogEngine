import React from "react";

import Main from "./main";

function App() {
  let props = {
    blogs: [],
  };

  props.blogs = getProps();

  return (
    <div>
      <h1>Welcome!</h1>
    </div>
  );
}

function getProps() {
  let result;
  fetch("https://blog-engine-api.herokuapp.com/api/blogs", { method: "GET" }).then(
    (res) => (result = res)
  );
  console.log(result);
  return result;
}

export default App;
