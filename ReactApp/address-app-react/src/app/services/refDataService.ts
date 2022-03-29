import Service from "./service";

export default class RefDataService {
    loadCountries = async () => {
        try {
            return await Service.RefData.countries();
        } 
        catch (error) {
            console.log(error);
        }
    }

    loadStates = async () => {
        try {
            return await Service.RefData.states();
        } 
        catch (error) {
            console.log(error);
        }
    }
}