import { JSX } from "@emotion/react/jsx-runtime";

export interface IOpcaoSidebar {
  id: number;
  href?: string | null | undefined;
  title: string;
  items?: Array<IOpcaoSidebar> | null;
  icon?: JSX.Element | undefined;
}
