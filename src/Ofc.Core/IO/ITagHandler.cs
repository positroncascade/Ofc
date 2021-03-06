﻿namespace Ofc.Core.IO
{
    using JetBrains.Annotations;
    using Parsing;

    internal interface ITagHandler
    {
        void StartObject(string name);

        void EndObject();

        void StartEntry(string name);

        void EndEntry();

        void StartList(OfcListType type, int capacity);

        void EndList();


        void HandleCompression();

        void HandleKeyword(string value);

        void HandleString(string value);

        void HandleDirective(OfcDirectiveType directive, [CanBeNull] string data);

        void HandleDimension(double[] values);

        void HandleScalar(double value);

        void HandleVector(double[] values);

        void HandleTensor(double[] tensor);
    }
}