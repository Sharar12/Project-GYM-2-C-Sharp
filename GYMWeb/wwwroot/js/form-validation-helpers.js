function validateBangladeshPhone(phone) {
    const regex = /^(?:\+88|88)?(01[3-9]\d{8})$/;
    return regex.test(phone);
}
