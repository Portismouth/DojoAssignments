from flask import Flask, render_template, request, redirect, url_for, flash, session
app = Flask(__name__)
app.secret_key = 'KeepItSecretKeepItSafe'

# Our index route will handle rendering our form
@app.route('/')
def index():
    return render_template("index.html")

@app.route('/results')
def results():
    return render_template("results.html")

@app.route('/process', methods=["POST"])
def submit():
    session['name'] = request.form["name"]
    session['language'] = request.form["language"]
    session['location'] = request.form["location"]
    session['comments'] = request.form['comments']
    if len(session['name']) < 1 or len(session['language']) < 1 or len(session['comments']) < 1:
        flash("field(s) cannot be left empty! Please fill out all information")
    elif len(session['comments']) > 120:
        flash("Only 120 characters allowed in comments text area")
    else:
        flash("Success, Thanks for submitting")
    return redirect("/")

app.run(debug=True)