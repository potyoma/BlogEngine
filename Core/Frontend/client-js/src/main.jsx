import React from 'react';

import BlogCard from "./components/blogCard"

function Main(props) {
    return (
        <div>
            {props.forEach(element => 
                <BlogCard blog={element} />)}
        </div>
    )
}

export default Main