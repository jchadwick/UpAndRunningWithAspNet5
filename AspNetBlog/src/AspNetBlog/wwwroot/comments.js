$(function initializeCommentComponents() {

    $(document).on('click', '.show-comments', function (evt) {
        evt.stopPropagation();
        new Post(this).showComments();
        return false;
    });

    $(document).on('click', '.add-comment', function (evt) {
        evt.stopPropagation();
        new Post(this).showAddComment();
        return false;
    });

    $(document).on('submit', '.new-comment form', function (evt) {
        evt.stopPropagation();
        new Post(this).addComment();
        return false;
    });
});

/*  Post class as an object-oriented wrapper around DOM elements */
function Post(el) {

    var $el = $(el),
        postEl = $el.hasClass('blog-post') ? $el : $el.parents('.blog-post'),
        postId = postEl.data('post-id'),
        addCommentEl = postEl.find('.add-comment'),
        newCommentEl = postEl.find('.new-comment'),
        commentEl = newCommentEl.find('[name=Body]'),
        commentsContainer = postEl.find('.comments-container'),
        commentsEl = postEl.find('.comments'),
        showCommentsButton = postEl.find('.show-comments'),
        noCommentsEl = postEl.find('.no-comments');


    return {
        addComment: addComment,
        renderComment: renderComments,
        showAddComment: showAddComment,
        showComments: showComments,
    };


    /*********  Public methods ****************/
    function addComment() {
        var comment = {
            PostId: postId,
            Body: commentEl.val(),
        };
        PostCommentService.addComment(comment).then(renderComments);
    }

    function showAddComment() {
        addCommentEl.addClass('hide');
        newCommentEl.removeClass('hide');
        commentEl.focus();
    }

    function showComments() {
        PostCommentService.getComments(postId).then(renderComments);
    }



    /*********  Private methods ****************/
    function createCommentElements(comments) {
        comments = [].concat(comments);

        if (!comments.length) {
            return $('<div class="no-comments">No comments</div>');
        }

        return comments.reduce(function (commentEls, comment) {
            var el =
                $('<div class="comment">')
                    .data('comment-id', comment.Id)
                    .append($('<p class="details">').append(comment.Author || 'Anon').append(' at ' + new Date(comment.PostedDate).toLocaleString()))
                    .append($('<p class="body">').append(comment.Body));

            return commentEls.concat(el);
        }, []);
    }

    function renderComments(comments) {
        var commentEls = createCommentElements(comments);
        commentsEl.append(commentEls);
        commentsContainer.removeClass('hide');
        showCommentsButton.remove();
        noCommentsEl.remove();
        resetAddComment();
    }

    function resetAddComment() {
        addCommentEl.removeClass('hide');
        newCommentEl.addClass('hide');
        commentEl.val('');
    }
}



var PostCommentService = (
    function PostCommentService() {

        function call(postId, method, data) {
            return $.ajax({
                // RESTful Web API URL:  /api/posts/{postId}/comments
                url: ['/api/posts', postId, 'comments'].join('/'),
                type: method,
                data: JSON.stringify(data),
                contentType: 'application/json'
            });
        }

        return {

            // Add comment by calling URL with POST method and passing data
            addComment: function (comment) {
                return call(comment.PostId, 'POST', comment);
            },

            // Get comments by calling URL with GET method
            getComments: function (postId) {
                return call(postId, 'GET');
            }
        };
    })();

