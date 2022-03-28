import axios, { AxiosResponse } from "axios";
import { AddressDetailModel } from "../models/addresses/AddressDetailModel";
import { AddressModel } from "../models/addresses/AddressModel";
import { AddressSearchModel } from "../models/addresses/AddressSearchModel";
import { AddressSearchResultsModel } from "../models/addresses/AddressSearchResultsModel";
import { PersonDetailModel } from "../models/people/PersonDetailModel";
import { PersonModel } from "../models/people/PersonModel";
import { PersonSearchModel } from "../models/people/PersonSearchModel";
import { PersonSearchResultsModel } from "../models/people/PersonSearchResultsModel";


axios.defaults.baseURL = 'https://localhost:5010';

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T>(url: string) => axios.get<T>(url).then(responseBody),
    post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    delete: <T>(url: string) => axios.delete<T>(url).then(responseBody),
}
 
const People = {
    search: (params: PersonSearchModel)=> {
        return axios.post<PersonSearchResultsModel[]>('/people/search', params)
            .then(responseBody);
    },

    list: () => {
        return axios.get<PersonModel[]>('/people')
            .then(responseBody);
    },
    details: (id: string) => {
        return requests.get<PersonDetailModel>(`/people/${id}`);
    },
    save: (person: PersonDetailModel) => {
        return requests.post<string[]>('/people', person);
    },
    delete: (id: string) => {
        return requests.delete<boolean>(`/people/${id}`);
    }
}


const Addresses = {
    search: (params: AddressSearchModel)=> {
        return axios.post<AddressSearchResultsModel[]>('/addresses/search', params)
            .then(responseBody);
    },
    list: () => {
        return axios.get<AddressModel[]>('/addresses')
            .then(responseBody)
    },
    details: (id: string) => {
        return requests.get<AddressDetailModel>(`/addresses/${id}`);
    },
    save: (movie: AddressModel) => {
        return requests.post<string[]>('/addresses', movie);
    }

}

const Service = {
    People,
    Addresses
}

export default Service;