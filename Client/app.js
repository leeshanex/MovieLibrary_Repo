(function($){
    function processForm( e ){
        var dict = {
            Title : this["title"].value,
            Director: this["director"].value,
            Genre: this["genre"].value
        };

        $.ajax({
            url: 'https://localhost:44325/api/movie',
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function( data, textStatus, jQxhr ){
                $('#response pre').html( data );
            },
            error: function( jqXhr, textStatus, errorThrown ){
                console.log( errorThrown );
            }
        });

        e.preventDefault();
    }

    $('#my-form').submit( processForm );
})(jQuery);

//display/see details
  	function getAllMovies(){
    	$("#displayMovieTable").html(" ");
    	$.ajax({
        url: "https://localhost:44325/api/movie",
        contentType: "application/json",
        type: 'get',
        success: function (data, textStatus, jQxhr){
            console.log("Success!");
            console.log(data);
            for (let i = 0; i<data.length; i++){
                $("#displayMovieTable").append(
                `<p>Title: ${data[i]["title"]}
                Director: ${data[i]["director"]}
                Genre: ${data[i]["genre"]} </p>`)
            };
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log("Error!");
            console.log(errorThrown);
        },
    });

//update details
    $(document).ready(function updateMovies(){
    	$('.updateButton').on('click', function(){
    		//var title = $(this).attr('title');
    		var title = $('#titleInput').val();
    		var director = $('#directorInput').val();
    		var genre = $('#genreInput').val();

    		req = $.ajax({
    			url : "https://localhost:44325/api/movie",
    			type : 'put',
    			data : {title : title, director : director, genre : genre},
    		});

    		req.done(function(data){
    			$('#titleInput').text(data["title"]);
    		})
    	})
    })
};
//     	$.ajax({
//     		url: "https://localhost:44325/api/movie",
//     		contentType: "application/json",
//     		type: 'put',
//     		success: function (data, textStatus, jQxhr){
//     			console.log("Success!");
//     			console.log(data);
//     		},
//     		error: function (jqXhr, textStatus, errorThrown) {
//     			console.log("Error!");
//     			console.log(errorThrown);
//     		},
//     	})
//     }
//   }
// //add a new movie
  // function addMovies() {
  // 	$().post("https://localhost:44325/api/movie", data, function(result){
  // 		$().html(result);
		//   	},json)
  // }
  	// $.ajax({
  	// 	url: "https://localhost:44325/api/movie",
  	// 	contentType: "application/json",
  	// 	type: 'post',
  	// 	success: function (data,textStatus,jQxhr){
  	// 		console.log("Success!");
  	// 		console.log(data);
  	// 	},
  	// 	error: function (jqXhr, textStatus, errorThrownr){
  	// 		console.log("Error!");
  	// 		console.log(errorThrown);
  	// 	},
  // 	})
  // }