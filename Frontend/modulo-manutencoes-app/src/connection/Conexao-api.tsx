import axios, {
  AxiosInstance,
  AxiosResponse,
  InternalAxiosRequestConfig,
} from "axios";
import getItemLocalStorage from "../utils/localStorage/getItemLocalStorage";

const api: AxiosInstance = axios.create({
  baseURL: "https://localhost:7021/api/",
});

api.interceptors.request.use(
  async (
    config: InternalAxiosRequestConfig<any>
  ): Promise<InternalAxiosRequestConfig<any>> => {
    const token = getItemLocalStorage("token");
    if (token !== null) {
      config.headers.Authorization = `Bearer ${token}`;
    }

    return config;
  },
  async (error: Error): Promise<never> => {
    return Promise.reject(error);
  }
);

api.interceptors.response.use(
  async (
    response: AxiosResponse<any, any>
  ): Promise<AxiosResponse<any, any>> => {
    return response;
  },
  async (error: Error): Promise<never> => {
    return Promise.reject(error);
  }
);

export default api;
