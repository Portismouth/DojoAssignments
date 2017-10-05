from flask import Flask, render_template, request, redirect, url_for
app = Flask(__name__)
# Our index route will handle rendering our form
@app.route('/')
def index():
    return render_template("index.html")

@app.route('/results')
def results():
    return render_template("results.html")

@app.route('/process', methods=["POST"])
def submit():
    name = request.form["name"]
    language = request.form["language"]
    return render_template("results.html", name = name, language = language)

app.run(debug=True)