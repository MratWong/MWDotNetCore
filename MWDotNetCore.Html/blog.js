const tblBlog = "blogs";
let blogId = '';
GetBlogTable();
getBlogs();
// testConfirmation();

function testConfirmation() {
    let confirmMessage = new Promise(function(success, error) {
        Swal.fire({
            title: "Confirm",
            text: "Are you sure want to delete?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!"
        }).then((result) => {
            if (result.isConfirmed) {
                success();
            } else {
                error();
            }

        });
    });

    confirmMessage.then(
        function(value) {
            successsMessage("Success");
        },
        function(error) {
            errorMessage("Error!");
        }
    );
}

function readBlog() {
    getBlogs();
}

function createBlog(title, author, content) {
    let lst = getBlogs();
    const requestModel = {
        id: uuidv4(),
        title: title,
        author: author,
        content: content

    }
    lst.push(requestModel);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);

    successsMessage("Save successfully!");
}

function editBlog(id) {
    let lst = getBlogs();
    const items = lst.filter(x => x.id == id);
    if (items.length == 0) {
        console.log("No data found!");
        return;
    }

    let item = items[0];
    blogId = item.id;
    $('#txtTitle').val(item.title);
    $('#txtAuthor').val(item.author);
    $('#txtContent').val(item.content);
}

function updateBlog(id, title, author, content) {

    let lst = getBlogs();

    const items = lst.filter(x => x.id === id);

    if (items.length == 0) {
        console.log("No data found!");
        return;
    }
    const item = items[0];
    item.title = title;
    item.author = author;
    item.content = content;

    const index = lst.findIndex(x => x.id === id);
    lst[index] = item;

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
}

function deleteBlog(id) {

    confirmMessage("Are you sure want to delete?").then(
        function(value) {
            let lst = getBlogs();

            const items = lst.filter(x => x.id === id);

            if (items.length == 0) {
                console.log("No data found!");
                return;
            }

            lst = lst.filter(x => x.id !== id);
            const jsonBlog = JSON.stringify(lst);
            localStorage.setItem(tblBlog, jsonBlog);
            successsMessage("Deleted successfully!");
            GetBlogTable();
        }
    )
}

function getBlogs() {
    const blogs = localStorage.getItem(tblBlog);
    let lst = [];

    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }
    return lst;
}


$('#btnSave').click(function() {
    const title = $('#txtTitle').val();
    const author = $('#txtAuthor').val();
    const content = $('#txtContent').val();
    if (blogId == '') {
        createBlog(title, author, content);
    } else {
        updateBlog(blogId, title, author, content);
        successsMessage("Updated successfully!");
    }
    clearControls();
    GetBlogTable();
})

function clearControls() {
    $('#txtTitle').val('');
    $('#txtAuthor').val('');
    $('#txtContent').val('');
}

function GetBlogTable() {
    const lst = getBlogs();
    let count = 0;
    let htmlRows = '';

    lst.forEach(item => {
        const htmlRow = `<tr>
                    <td>
                        <div class="btn btn-warning" id="btnEdit" onclick="editBlog('${item.id}')">Edit</div>
                        <div class="btn btn-danger" id="btnDelete" onclick="deleteBlog('${item.id}')">Delete</div>
                    </td>
                    <th scope="row">${++count}</th>
                    <td>${item.title}</td>
                    <td>${item.author}</td>
                    <td>${item.content}</td>
                </tr>`;
        htmlRows += htmlRow;
    });

    $('#blogData').html(htmlRows);
}