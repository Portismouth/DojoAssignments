from flask import Flask, render_template, request, redirect
app = Flask(__name__)
# Our index route will handle rendering our form
@app.route('/')
def index():
    return render_template("index.html")

@app.route('/success')
def success():
    return render_template("success.html")

#form submission
@app.route('/users', methods=['POST'])
def create_user():
    print "Got Post Info"
    name = request.form['name']
    email = request.form['email']
    print "Name: {} Email: {}".format(name, email)
    return redirect('/success')

app.run(debug=True)