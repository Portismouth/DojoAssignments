//Database connection
var mongoose = require("mongoose");



//pulling in the model
var User = mongoose.model('User')

module.exports = {

    showAll: function(req, res) {
        User.find({}, function(err, data) {
            res.json(data);
        })
    },

    load: function(req, res, page) {
        if (req.session.userId) {
            User.findOne({_id: req.session.userId}, function(err, user) {
                if(err) {
                    console.log(err);
                    res.render(page, {context: null});
                } else {
                    res.render(page, {context: user})
                }
            })
        } else {
            res.render(page, {context: null});
        }
        
    },

    register: function(req, res) {
       if(req.body.password != req.body.confirm){
           let errors = [{'message': ''}];
           errors[0]['message'] = 'Passwords do not match';
           res.render('index', {errorsRegister: errors});
       } else {
           var newUser = new User ({
               firstName: req.body.firstName,
               lastName: req.body.lastName,
               name: req.body.lastName,
               email: req.body.email,
               password: req.body.password
           });
           newUser.save(function(err) {
               if(err) {
                   console.log(err.errors)
                   res.render('index', {errorsRegister: err.errors, context: null});
               } else {
                    User.findOne({email: req.body.email}, function(errOther, user) {
                        console.log(user._id)
                        req.session.userId = user._id
                        res.redirect("/");
                    });  
               }
           });
       }
    },

    login: function(req, res) {
        User.findOne({email: req.body.emailLogin}, function(error, user){
            if(error){
                res.render('index', {errorsLogin: error})
            } else if (user == null) {
                console.log("Email is not in our database");
                res.redirect('/')
            } else {
                user.comparePassword(req.body.passwordLogin, function(errPass, isMatch) {
                    console.log(isMatch)
                    if(!isMatch){
                        console.log('fail, incorrect password');
                        res.redirect("/");
                    } else {
                        console.log('success');
                        req.session.userId = user._id
                        res.redirect("/");
                    }
                });
            }
        });
    },

    logout: function(req, res) {
        req.session.destroy();
        res.redirect("/")
    }
}