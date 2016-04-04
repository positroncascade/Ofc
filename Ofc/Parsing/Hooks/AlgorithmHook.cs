﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OfcAlgorithm.Integration;
using OfcCore;
using OfcCore.Configurations;

namespace Ofc.Parsing.Hooks
{
    internal class AlgorithmHook : IParserHook<string>
    {
        private readonly IAlgorithm<OfcNumber> _algorithm;
        private readonly Stream _output;
        private IReporter<OfcNumber> _compress;

        public AlgorithmHook(IAlgorithm<OfcNumber> algorithm, Stream output)
        {
            _algorithm = algorithm;
            _output = output;
        }


        public void EnterDictionary(string name)
        {

        }

        public void LeaveDictionary()
        {

        }

        public void EnterCodeStreamDictionary(string name)
        {

        }

        public void LeaveCodeStreamDictionary()
        {

        }

        public void EnterEntry(string name)
        {

        }

        public void LeaveEntry()
        {

        }

        public void EnterList(OfcListType type, int capacity)
        {
            if(_compress != null) throw new NotSupportedException();

            _compress = _algorithm.Compress(null, EmptyConfiguration.Instance, _output, (int)type, capacity);
        }

        public void HandleListEntry(string value)
        {
            _compress.Report(OfcNumber.Parse(value));
        }

        public void HandleListEntries(string[] values)
        {
            // ReSharper disable once ForCanBeConvertedToForeach
            for (var index = 0; index < values.Length; index++)
            {
                HandleListEntry(values[index]);
            }
        }

        public void LeaveList()
        {
            _compress.Finish();
            _compress = null;
        }

        public void HandleMacro(OfcMacroType macro, string data)
        {

        }

        public void HandleDimension(string[] values)
        {

        }

        public void HandleScalar(string value)
        {

        }

        public void HandleKeyword(string value)
        {

        }

        public void HandleString(string data)
        {

        }

        public void Flush()
        {

        }
    }
}