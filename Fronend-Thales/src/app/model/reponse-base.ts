export class ResponseBase<T> {
    public code: number;
    public data: T;
    public message: string;
}
