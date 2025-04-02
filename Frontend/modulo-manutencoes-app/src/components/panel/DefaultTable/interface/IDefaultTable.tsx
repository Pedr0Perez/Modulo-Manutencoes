import { JSX } from "@emotion/react/jsx-runtime";

export interface IDefaultTable<T> {
  children?: JSX.Element;
  list?: Array<T>;
  columnsList: Array<string>;
  filter?: boolean;
}
