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
        contentType: 'application/json',
        type: 'get',
        success: function (data, textStatus, jQxhr){
            console.log("Success!");
            console.log(data);
            for (let i = 0; i<data.length; i++){
                $("#displayMovieTable").append(
                `<tr><td>Title: ${data[i]["title"]}
                Director: ${data[i]["director"]}
                Genre: ${data[i]["genre"]} </td></tr>`)
            };
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log("Error!");
            console.log(errorThrown);
        },
    });

//update details
function updateMovies(){
	$.ajax({
		url: "https://localhost:44325/api/movie",
		dataType: 'json',
		contentType: 'application/json',
		type: 'put',
		data: JSON.replaceWith(dict),
		 success: function (data, textStatus, jQxhr){
            console.log("Success!");
            console.log(data);

    },
       error: function (jqXhr, textStatus, errorThrown) {
            console.log("Error!");
            console.log(errorThrown);
        },

	})

// add a new movie
  function addMovies(){ 

  	$.ajax({
  		url: "https://localhost:44325/api/movie",
  		dataType: 'json',
  		contentType: 'application/json',
  		type: 'post',
  		data: JSON.append(dict),
  		success: function (data,textStatus,jQxhr){
  			$('#response pre').html(data);
  			console.log("Success!");
  			console.log(data);
  			
  		},
  		error: function (jqXhr, textStatus, errorThrownr){
  			console.log("Error!");
  			console.log(errorThrown);
  		},
  	})
  }
  }
}

