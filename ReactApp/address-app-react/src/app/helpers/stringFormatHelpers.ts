export const formatTitle = (name: string, place: string) => {
    return name  + " - " + place;
};

export const isNullOrWhitespace = (value?: string) => {
    if(value){
        return value.replace(/\s/g, '').length < 1;
    }
    return true;
}