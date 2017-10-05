from flask import Flask, render_template, request, redirect, url_for
app = Flask(__name__)
# Our index route will handle rendering our form
@app.route('/')
def index():
    return render_template("index.html")

@app.route('/ninja', strict_slashes=False)
def ninja():
    return render_template("ninja.html")

@app.route('/ninja/<color>')
def specific_ninja(color):
    return render_template("specific_ninja.html", color = color)

app.run(debug=True)