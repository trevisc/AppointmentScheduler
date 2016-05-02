# AppointmentScheduler
RESTful API for scheduling dr appointments using NancyFX

There is a unit test solution or you can use the notes below for testing the API

Mock Data is in the ScheduleAPI.Data project under /Data/MockData.cs

Test Scenarios:
http://localhost:2016/appointment/1/2/3/Cut%20Hand/20/2016-04-15%2013:00:00%20PM

Should schedule appointment.
Message:
{"serviceName":"Create Appointment","responseCode":"200","responseMessage":["Appointment Scheduled Successfully."]}

http://localhost:2016/ScheduleAppointment/1/2/3/Cut%20Hand/20/2016-04-15%2016:01:00%20PM

Can't schedule because the appointment time is past the closing time (16:00);
Message:
{"serviceName":"Create Appointment","responseCode":"999","responseMessage":["Scheduled time is outside of normal business hours."]}

Get a list of appointments by provider for a particular date:
http://localhost:2016/GetAppointmentsByProdiver/2/2016-04-15

Returns:
[{"id":"1","patientId":"1","providerId":"2","serviceId":"4","reasonForVisit":"Got The Hives","plannedDuration":20,"starts":"04/15/2016 09:00:00 AM"},{"id":"2","patientId":"2","providerId":"2","serviceId":"1","reasonForVisit":"Sick","plannedDuration":10,"starts":"04/15/2016 09:25:00 AM"}]

Certification Level Test:
http://localhost:2016/ScheduleAppointment/1/2/2/Cut%20Hand/20/2016-04-15%2015:00:00%20PM
Fails with:
{"serviceName":"Create Appointment","responseCode":"999","responseMessage":["Provider selected does not have high enough certification level."]}

Age Limit:
http://localhost:2016/ScheduleAppointment/5/2/3/Cut%20Hand/20/2016-04-15%2015:00:00%20PM

Fails with:
{"serviceName":"Create Appointment","responseCode":"999","responseMessage":["Patient is not old enough for this service."]}

Physician Is Available Test:
http://localhost:2016/ScheduleAppointment/2/1/2/Cut%20Hand/20/2016-04-15%2009:39:00%20AM
Returns false:
{"serviceName":"Create Appointment","responseCode":"999","responseMessage":["Provider is not available to perform this service"]}

Because he has a scheduled Appointment from 9:25 to 9:35 plus his 5 minute break (9:40)

This one passes:
http://localhost:2016/ScheduleAppointment/2/1/2/Cut%20Hand/20/2016-04-15%2009:40:00%20AM
{"serviceName":"Create Appointment","responseCode":"200","responseMessage":["Appointment Scheduled Successfully."]}

