import { JSX } from "@emotion/react/jsx-runtime";

export interface IDefaultCardProps {
  titulo: string;
  icon?: JSX.Element | undefined;
  descricao?: string | undefined;
  children?: JSX.Element;
}
