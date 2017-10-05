from flask import Flask, render_template, request, redirect
app = Flask(__name__)
# Our index route will handle rendering our form
@app.route('/')
def index():
    return render_template("index.html")

@app.route('/ninjas')
def ninjas():
    return render_template("ninjas.html")

@app.route('/dojos/new')
def dojos():
    return render_template("dojos.html")

#form submission
@app.route('/form_submit', methods=['POST'])
def form_submit():
    print "Got Post Info"
    name = request.form['name']
    email = request.form['email']
    print "Name: {} Email: {}".format(name, email)
    return redirect('/dojos/new')

app.run(debug=True)