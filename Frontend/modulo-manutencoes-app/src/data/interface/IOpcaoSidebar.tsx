export interface IOpcaoSidebar {
  id: number;
  href: string | null;
  title: string;
  items?: Array<IOpcaoSidebar> | null;
}
