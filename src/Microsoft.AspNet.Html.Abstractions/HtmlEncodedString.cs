﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Text.Encodings.Web;

namespace Microsoft.AspNet.Html
{
    /// <summary>
    /// An <see cref="IHtmlContent"/> implementation that wraps an HTML encoded <see cref="string"/>.
    /// </summary>
    public class HtmlEncodedString : IHtmlContent
    {
        /// <summary>
        /// An <see cref="IHtmlContent"/> instance for <see cref="Environment.NewLine"/>.
        /// </summary>
        public static readonly IHtmlContent NewLine = new HtmlEncodedString(Environment.NewLine);

        private readonly string _value;

        /// <summary>
        /// Creates a new <see cref="HtmlEncodedString"/>.
        /// </summary>
        /// <param name="value">The HTML encoded value.</param>
        public HtmlEncodedString(string value)
        {
            _value = value;
        }

        /// <inheritdoc />
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (encoder == null)
            {
                throw new ArgumentNullException(nameof(encoder));
            }

            writer.Write(_value);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return _value ?? string.Empty;
        }
    }
}
