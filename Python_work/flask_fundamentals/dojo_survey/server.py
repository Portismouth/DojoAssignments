from flask import Flask, render_template, request, redirect, url_for
app = Flask(__name__)
# Our index route will handle rendering our form
@app.route('/')
def index():
    return render_template("index.html")

@app.route('/result')
def result(name,location, language, message):
    return render_template("result.html", name = name, location = location, language = language, message = message)

#form submission
@app.route('/form_submit', methods=['POST'])
def form_submit():
    print "Got Post Info"
    name = request.form['name']
    location = request.form['location']
    language = request.form['language']
    message = request.form['message']
    # return render_template('result.html', name = name, location = location, language=language, message = message)
    return result(name,location,language,message)
app.run(debug=True)