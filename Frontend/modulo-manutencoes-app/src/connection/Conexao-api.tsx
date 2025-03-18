import axios, {
  AxiosInstance,
  AxiosResponse,
  InternalAxiosRequestConfig,
} from "axios";

const api: AxiosInstance = axios.create({
  baseURL: "http://localhost:7173/api/",
});

api.interceptors.request.use(
  async (
    config: InternalAxiosRequestConfig<any>
  ): Promise<InternalAxiosRequestConfig<any>> => {
    return config;
  },
  async (error: any): Promise<never> => {
    return Promise.reject(error);
  }
);

api.interceptors.response.use(
  async (
    response: AxiosResponse<any, any>
  ): Promise<AxiosResponse<any, any>> => {
    return response;
  },
  async (error: any): Promise<never> => {
    return Promise.reject(error);
  }
);

export default api;
