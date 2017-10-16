$(function() {
    
        $('#login-form-link').click(function(e) {
            $("#login-form").delay(100).fadeIn(100);
             $("#register-form").fadeOut(100);
            $('#register-form-link').removeClass('active');
            $(this).addClass('active');
            e.preventDefault();
        });
        $('#register-form-link').click(function(e) {
            $("#register-form").delay(100).fadeIn(100);
             $("#login-form").fadeOut(100);
            $('#login-form-link').removeClass('active');
            $(this).addClass('active');
            e.preventDefault();
        });

        // //AJAX REGISTER SUBMIT
        // // this is the id of the form
        // $("#register-form").submit(function(e) {
        //     var url = "/register"; // the script where you handle the form input.
        //     $.ajax({
        //         type: "POST",
        //         url: url,
        //         data: $("#register-form").serialize(), // serializes the form's elements.
        //         success: function(data)
        //         {
        //             console.log(data)
        //             $("#register-form")[0].reset();
        //             $('.errors').html('{% for message in messages %}<li {% if message.tags %} class="{{ message.tags }}"{% endif %}>{{ message }}</li>{% endfor %}')
        //         }
        //         });
        //     e.preventDefault(); // avoid to execute the actual submit of the form.
        // });
    
    });
    