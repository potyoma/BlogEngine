## Blogs:
### API URL: https://blog-engine-api.herokuapp.com/api/blogs
### Methods:
 - GET: returns JSON file that contains all blog objects in db
 - "/{id}" GET: returns JSON file containing blog of the written id
 - POST: creates new blog made of sended data and returns it to client (it also contains unique token. save it)
 - "/{token}" PUT: updates blog info. Needs token for access.
 - "/{token}" DELETE: deletes account with the same token.

---

## Posts
### API URL: https://blog-engine-api.herokuapp.com/api/post
### Methods:
 - "/{blogURLName}" GET: returns all posts in blog
 - "/get/{postId}" GET: returns a post of id
 - "/{token}" POST: creates new post in a blog of the token
 - "/{token}/{postId}" PUT: updates post of postId in a blog of the token
 - "/{token}/{postId}" DELETE: removes post of postId from blog of the token

---

## About token

Token is a generated unique access key. It's the only way you can access your blog and posts. Keep it and make sure you won't loose it or give to anyone else.