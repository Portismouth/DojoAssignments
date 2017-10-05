from flask import Flask, render_template, request, redirect
app = Flask(__name__)
# Our index route will handle rendering our form
@app.route('/')
def index():
    return render_template("index.html")

#form submission
@app.route('/process', methods=['POST'])
def form_submit():
    print "Got Post Info"
    name = request.form['name']
    print "Name: {}".format(name)
    return redirect('/')

app.run(debug=True)