class Patient(object):
    paitent_id = 0
    def __init__(self, name, allergies, bed_number="none"):
        self.name = name
        self.allergies = allergies
        self.bed_number = bed_number
        self.paitent_id = Patient.paitent_id
        Patient.paitent_id += 1
    def get_info(self) :
        print "Name: {}\nAllergies: {}\nBed Number: {}\n".format(self.name, self.allergies, self.bed_number)
        return self   
        
class Hospital(object):
    def __init__(self, hospital, capacity):
        self.patients = []
        self.hospital = hospital
        self.capacity = capacity
        self.bed_counter = 0
    def admit(self, patient):
        if len(self.patients) < self.capacity:
            self.patients.append(patient)
            self.bed_counter += 1
            patient.bed_number = self.bed_counter
            print patient.name,"has been admitted\n"
        else: 
            print "Sorry we cannot admit you, the hospital is at capacity"
        return self
    def discharge(self, id):
        for patient in self.patients:
            if id == patient.paitent_id:
                del self.patients[self.patients.index(patient)]
                patient.bed_number = None
                print patient.name,"Mitchell has been Discharged \n"
        return self
    def info(self):
        for person in self.patients:
            person.get_info()

h = Hospital("Chicago Med" , 10)
p1 = Patient("Mitchell", None)

h.admit(p1).admit(Patient("Second", "Peanuts")).discharge(0).admit(Patient("John", None)).info()