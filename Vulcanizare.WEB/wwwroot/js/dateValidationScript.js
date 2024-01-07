$(document).ready(function () {
    // Handle change event for ServiceType dropdown
    $("#Appointment_AppointmentDate").datetimepicker({
        format: 'YYYY-MM-DD HH:mm',   // Formatul datelor și orei
        minDate: moment().startOf('hour').add(6, 'hours'),  // Data și ora de început (aici, 6 dimineața)
        maxDate: moment().startOf('hour').add(24, 'hours')  // Data și ora de sfârșit (aici, 12 noaptea)
    });
});