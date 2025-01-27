export interface Orden {    
    IdOrden: number;
    IdPaciente: number;
    IdMedico: number;
    IdEspecimen: number;
    FechaRecepcion: Date;
    FechaEntrega: Date;
    Diagnostico: String;
    Precio: number;
    Clave: String;
    Entrega: String;
    Observaciones: String;
    Estatus: number;
    Pagado: boolean;
    Activo: number;
    Entregado: boolean;
  }