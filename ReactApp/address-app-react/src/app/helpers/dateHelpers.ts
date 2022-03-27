import moment from "moment";

export const formatAsUTC = (date: Date | undefined | null): Date | null => {
    const utcDate = date ? moment(date).format('yyyy-MM-DD 00:00:00+00:00') : null;
    if(utcDate != null) return new Date(utcDate);
    return utcDate;
};

export const formatDatePicker = (date: Date | null) => {
    if(!!date) return moment(date).startOf('day').toDate();
    return null;
}
